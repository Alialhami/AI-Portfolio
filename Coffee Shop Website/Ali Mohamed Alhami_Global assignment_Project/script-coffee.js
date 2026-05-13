// Bean Boutique - Coffee Selection Page Script
// ==========================================
// Bean Boutique - [Coffee Selection] Script
// Author: Ali Mohamed ALI AGHA AL HAMI
// Student ID: 216968
// ==========================================

document.addEventListener('DOMContentLoaded', function () {
    // ----- the Hamburger Menu for Mobile -----
    const hamburger = document.querySelector('.hamburger');
    const navLinks = document.querySelector('.nav-links');
    if (hamburger && navLinks) {
        hamburger.addEventListener('click', () => {
            navLinks.classList.toggle('active');
        });
    }

    // ----- the Coffee Data Array with Images -----
    const coffeeData = [
        {
            name: 'Ethiopian Yirgacheffe',
            description: 'Floral, citrus, light body.',
            method: 'Pour-over, Aeropress',
            image: 'images/ethiopian.jpg'
        },
        {
            name: 'Colombian Supremo',
            description: 'Nutty, chocolate, medium body.',
            method: 'French Press, Espresso',
            image: 'images/colombian.jpg'
        },
        {
            name: 'Sumatra Mandheling',
            description: 'Earthy, herbal, full body.',
            method: 'French Press, Cold Brew',
            image: 'images/sumatra.jpg'
        },
        {
            name: 'Signature Espresso Blend',
            description: 'Rich crema, dark chocolate notes.',
            method: 'Espresso Machine',
            image: 'images/espresso-blend.jpg'
        },
        {
            name: 'Decaf Swiss Water',
            description: 'Smooth, caramel, without caffeine.',
            method: 'Any',
            image: 'images/decaf.jpg'
        }
    ];

    const catalogueContainer = document.getElementById('coffeeCatalogue');
    let cart = JSON.parse(localStorage.getItem('cart')) || [];

    // ----- here we have the Render Catalogue Function -----
    function renderCatalogue(filterText = '') {
        if (!catalogueContainer) return;
        catalogueContainer.innerHTML = '';
        coffeeData.forEach(coffee => {
            
            if (filterText && !coffee.name.toLowerCase().includes(filterText.toLowerCase())) return;
            const item = document.createElement('div');
            item.className = 'coffee-item';

            
            item.innerHTML = `
                <img src="${coffee.image}" alt="${coffee.name}">
                <h3>${coffee.name}</h3>
                <p>${coffee.description}</p>
                <p><strong>Brewing method:</strong> ${coffee.method}</p>
                <button class="btn add-to-cart" data-id="${coffee.name.replace(/\s/g, '')}" data-name="${coffee.name}" data-price="12.99">Add to Cart</button>
            `;
            catalogueContainer.appendChild(item);
        });

        //  here we Attach event listeners to all "Add to Cart" buttons after rendering
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
    }

    //  here we have the Initial render (all coffees)
    renderCatalogue();

    // ----- the Animated Text Search -----
    const searchInput = document.getElementById('coffeeSearch');
    if (searchInput) {
        searchInput.addEventListener('input', (e) => {
            renderCatalogue(e.target.value);
            // Add a brief highlight animation to matching items
            document.querySelectorAll('.coffee-item').forEach(item => {
                item.classList.add('highlight');
                setTimeout(() => item.classList.remove('highlight'), 500);
            });
        });
    }

    
    

    // ----- the Reviews Carousel -----
    let reviewIndex = 0;
    window.prevReview = function () {
        const reviews = document.querySelectorAll('.review');
        if (reviews.length) {
            reviews[reviewIndex].classList.remove('active');
            reviewIndex = (reviewIndex - 1 + reviews.length) % reviews.length;
            reviews[reviewIndex].classList.add('active');
        }
    };
    window.nextReview = function () {
        const reviews = document.querySelectorAll('.review');
        if (reviews.length) {
            reviews[reviewIndex].classList.remove('active');
            reviewIndex = (reviewIndex + 1) % reviews.length;
            reviews[reviewIndex].classList.add('active');
        }
    };

    // ----- the Next Roast Day Countdown Widget -----
function startCountdown() {
    // Set the next roast date (change as you like)
    const roastDate = new Date('May 1, 2025 08:00:00').getTime();

    const timer = setInterval(function() {
        const now = new Date().getTime();
        const distance = roastDate - now;

        //  the Time calculations
        const days = Math.floor(distance / (1000 * 60 * 60 * 24));
        const hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
        const minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
        const seconds = Math.floor((distance % (1000 * 60)) / 1000);

        // Update the HTML
        document.getElementById('days').textContent = String(days).padStart(2, '0');
        document.getElementById('hours').textContent = String(hours).padStart(2, '0');
        document.getElementById('mins').textContent = String(minutes).padStart(2, '0');
        document.getElementById('secs').textContent = String(seconds).padStart(2, '0');

        // here If the countdown is over, show a message
        if (distance < 0) {
            clearInterval(timer);
            document.getElementById('roastCountdown').innerHTML = '<span class="countdown-number">Roast Day!</span>';
        }
    }, 1000);
}

startCountdown();






});