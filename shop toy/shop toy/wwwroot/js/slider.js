document.addEventListener("DOMContentLoaded", function () {

    /* ================= SLIDER ================= */

    let currentIndex = 0;
    const slides = document.querySelectorAll(".slide");
    const totalSlides = slides.length;

    const nextBtn = document.querySelector(".next");
    const prevBtn = document.querySelector(".prev");

    function showSlide(index) {
        slides.forEach(slide => slide.classList.remove("active"));
        slides[index].classList.add("active");
    }

    function nextSlide() {
        currentIndex = (currentIndex + 1) % totalSlides;
        showSlide(currentIndex);
    }

    function prevSlide() {
        currentIndex = (currentIndex - 1 + totalSlides) % totalSlides;
        showSlide(currentIndex);
    }

    let autoSlide = setInterval(nextSlide, 5000);

    function resetAuto() {
        clearInterval(autoSlide);
        autoSlide = setInterval(nextSlide, 5000);
    }

    nextBtn.addEventListener("click", function () {
        nextSlide();
        resetAuto();
    });

    prevBtn.addEventListener("click", function () {
        prevSlide();
        resetAuto();
    });

    showSlide(currentIndex);


    document.addEventListener("DOMContentLoaded", function () {
        const items = document.querySelectorAll(".menu-box");
        const content = document.getElementById("content-area");

        items.forEach(item => {
            item.addEventListener("click", () => {
                const url = item.dataset.url;

                fetch("pages/" + url)
                    .then(res => res.text())
                    .then(html => {
                        content.innerHTML = html;
                    });
            });
        });
    });

    
});
