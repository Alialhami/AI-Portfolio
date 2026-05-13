// Bean Boutique - Events & Workshops Page Script

// ==========================================
// Bean Boutique - [Events & Workshops Page ] Script
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

    // ----- the Registration Form Toggle -----
    const registerBtns = document.querySelectorAll('.register-btn');
    const regForm = document.getElementById('registrationForm');
    const selectedEventSpan = document.getElementById('selectedEvent');
    const cancelReg = document.getElementById('cancelReg');

    registerBtns.forEach(btn => {
        btn.addEventListener('click', () => {
            const eventName = btn.dataset.event;
            selectedEventSpan.textContent = eventName;
            regForm.classList.remove('hidden');
        });
    });

    if (cancelReg) {
        cancelReg.addEventListener('click', () => {
            regForm.classList.add('hidden');
        });
    }

    // ----- the Form Submission -----
    const eventRegForm = document.getElementById('eventRegForm');
    if (eventRegForm) {
        eventRegForm.addEventListener('submit', (e) => {
            e.preventDefault();
            const firstName = document.getElementById('firstName').value;
            const email = document.getElementById('email').value;
            alert('Thank you ' + firstName + '! A confirmation email will be sent to ' + email + '.');
            regForm.classList.add('hidden');
            eventRegForm.reset();
        });
    }
});