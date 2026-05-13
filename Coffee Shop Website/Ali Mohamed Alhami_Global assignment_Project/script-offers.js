// Bean Boutique - Special Offers & Subscriptions Page Script

// ==========================================
// Bean Boutique - [Special Offers & Subscriptions Page ] Script
// Author: Ali Mohamed ALI AGHA AL HAMI
// Student ID: 216968
// ==========================================

document.addEventListener('DOMContentLoaded', function () {
    // the Hamburger menu
    const hamburger = document.querySelector('.hamburger');
    const navLinks = document.querySelector('.nav-links');
    if (hamburger && navLinks) {
        hamburger.addEventListener('click', () => {
            navLinks.classList.toggle('active');
        });
    }

    // ----- the Subscription Modal -----
    const subBtns = document.querySelectorAll('.subscribe-btn');
    const subModal = document.getElementById('subscribeModal');
    const planSpan = document.getElementById('planName');
    const closeSub = document.querySelector('.close-sub');

    subBtns.forEach(btn => {
        btn.addEventListener('click', () => {
            planSpan.textContent = btn.dataset.plan;
            subModal.classList.remove('hidden');
        });
    });

    if (closeSub) {
        closeSub.onclick = () => subModal.classList.add('hidden');
    }

    window.onclick = function (event) {
        if (event.target === subModal) subModal.classList.add('hidden');
    };

    const subForm = document.getElementById('subscribeForm');
    if (subForm) {
        subForm.addEventListener('submit', (e) => {
            e.preventDefault();
            alert('Subscription confirmed! Thank you.');
            subModal.classList.add('hidden');
        });
    }
});