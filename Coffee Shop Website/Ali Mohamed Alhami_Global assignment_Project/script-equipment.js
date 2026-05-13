// Bean Boutique - Brewing Equipment Page Script
// ==========================================
// Bean Boutique - [Brewing Equipment Page ] Script
// Author: Ali Mohamed ALI AGHA AL HAMI
// Student ID: 216968
// ==========================================

document.addEventListener('DOMContentLoaded', function () {
    // the Hamburger menu.
    const hamburger = document.querySelector('.hamburger');
    const navLinks = document.querySelector('.nav-links');
    if (hamburger && navLinks) {
        hamburger.addEventListener('click', () => {
            navLinks.classList.toggle('active');
        });
    }

    // Add to Cart functionality (same logic as other pages)
    let cart = JSON.parse(localStorage.getItem('cart')) || [];

    document.querySelectorAll('.add-to-cart').forEach(btn => {
        btn.addEventListener('click', (e) => {
            const id = btn.dataset.id;
            const name = btn.dataset.name;
            const price = parseFloat(btn.dataset.price);
            const existing = cart.find(item => item.id === id);
            if (existing) {
                existing.quantity += 1;
            } else {
                cart.push({ id, name, price, quantity: 1 });
            }
            localStorage.setItem('cart', JSON.stringify(cart));
            alert(name + ' added to cart!');
        });
    });
});