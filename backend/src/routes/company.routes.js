const express = require('express');
const router = express.Router();

// Placeholder routes - will be implemented
router.get('/', (req, res) => res.json({ message: 'Companies endpoint' }));
router.get('/users', (req, res) => res.json({ message: 'Users endpoint' }));
router.get('/products', (req, res) => res.json({ message: 'Products endpoint' }));
router.get('/vendors', (req, res) => res.json({ message: 'Vendors endpoint' }));
router.get('/accounts', (req, res) => res.json({ message: 'Accounts endpoint' }));

module.exports = router;
