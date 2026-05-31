const bcrypt = require('bcryptjs');
const pool = require('../config/database');
const { v4: uuidv4 } = require('uuid');
const { generateToken } = require('../config/jwt');

// Register User
const register = async (req, res) => {
  try {
    const { companyName, email, password, firstName, lastName, phone } = req.body;

    // Hash password
    const hashedPassword = await bcrypt.hash(password, 10);

    // Create company
    const companyId = uuidv4();
    const companyResult = await pool.query(
      `INSERT INTO companies (id, name, email) 
       VALUES ($1, $2, $3) RETURNING *`,
      [companyId, companyName, email]
    );

    // Create user
    const userId = uuidv4();
    const userResult = await pool.query(
      `INSERT INTO users (id, company_id, first_name, last_name, email, password_hash, phone, role)
       VALUES ($1, $2, $3, $4, $5, $6, $7, $8) RETURNING id, email, first_name, last_name, role`,
      [userId, companyId, firstName, lastName, email, hashedPassword, phone, 'admin']
    );

    const token = generateToken({
      id: userResult.rows[0].id,
      email: userResult.rows[0].email,
      role: userResult.rows[0].role,
      companyId: companyId
    });

    res.status(201).json({
      success: true,
      message: 'Company and user created successfully',
      token,
      user: userResult.rows[0],
      company: companyResult.rows[0]
    });
  } catch (err) {
    console.error('Registration error:', err);
    res.status(500).json({
      success: false,
      message: err.message
    });
  }
};

// Login User
const login = async (req, res) => {
  try {
    const { email, password } = req.body;

    const result = await pool.query(
      `SELECT u.*, c.id as company_id FROM users u 
       JOIN companies c ON u.company_id = c.id
       WHERE u.email = $1`,
      [email]
    );

    if (result.rows.length === 0) {
      return res.status(401).json({
        success: false,
        message: 'Invalid email or password'
      });
    }

    const user = result.rows[0];
    const passwordMatch = await bcrypt.compare(password, user.password_hash);

    if (!passwordMatch) {
      return res.status(401).json({
        success: false,
        message: 'Invalid email or password'
      });
    }

    // Update last login
    await pool.query(
      'UPDATE users SET last_login = NOW() WHERE id = $1',
      [user.id]
    );

    const token = generateToken({
      id: user.id,
      email: user.email,
      role: user.role,
      companyId: user.company_id
    });

    res.json({
      success: true,
      message: 'Login successful',
      token,
      user: {
        id: user.id,
        email: user.email,
        firstName: user.first_name,
        lastName: user.last_name,
        role: user.role,
        companyId: user.company_id
      }
    });
  } catch (err) {
    console.error('Login error:', err);
    res.status(500).json({
      success: false,
      message: err.message
    });
  }
};

module.exports = {
  register,
  login
};
