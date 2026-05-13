
// ==========================================
// Bean Boutique - [home] Script
// Author: Ali Mohamed ALI AGHA AL HAMI
// Student ID: 216968
// ==========================================

document.addEventListener('DOMContentLoaded', function () {
    // ----- Modal Popup (first-time visitor) -----
    if (!sessionStorage.getItem('modalShown')) {
        const modal = document.getElementById('discountModal');
        if (modal) {
            modal.style.display = 'block';
            sessionStorage.setItem('modalShown', 'true');
        }
    }

    const closeSpan = document.querySelector('.close');
    if (closeSpan) {
        closeSpan.onclick = function () {
            document.getElementById('discountModal').style.display = 'none';
        };
    }

    window.onclick = function (event) {
        const modal = document.getElementById('discountModal');
        if (event.target === modal) {
            modal.style.display = 'none';
        }
    };

    const modalForm = document.getElementById('modalSignupForm');
    if (modalForm) {
        modalForm.addEventListener('submit', function (e) {
            e.preventDefault();
            const email = document.getElementById('modalEmail').value;
            if (email) {
                alert('Thank you! Your discount code is BEAN15.');
                document.getElementById('discountModal').style.display = 'none';
            }
        });
    }

    // -----Here we have the  Slideshow -----
    let slideIndex = 1;
    const slides = document.getElementsByClassName("slide");
    if (slides.length > 0) {
        window.showSlides = function (n) {
            if (n > slides.length) slideIndex = 1;
            if (n < 1) slideIndex = slides.length;
            for (let i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            slides[slideIndex - 1].style.display = "block";
        };
        window.changeSlide = function (n) {
            showSlides(slideIndex += n);
        };
        showSlides(slideIndex);
        setInterval(function () { changeSlide(1); }, 5000);
    }

    // ----- the Hamburger Menu for (Mobile) -----
    const hamburger = document.querySelector('.hamburger');
    const navLinks = document.querySelector('.nav-links');
    if (hamburger && navLinks) {
        hamburger.addEventListener('click', () => {
            navLinks.classList.toggle('active');
        });
    }

    // ----- Add to Cart  -----
    let cart = JSON.parse(localStorage.getItem('cart')) || [];

    function updateCartDisplay() {
        // this is Only used on cart page, but kept for consistency
    }

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