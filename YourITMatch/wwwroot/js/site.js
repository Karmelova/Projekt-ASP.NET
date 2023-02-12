const navbar = document.getElementById('navbar');
const footer = document.getElementById('footer');

navbar.addEventListener('mouseover', function () {
    this.classList.remove('bg-opacity-75');
    this.classList.add('bg-opacity-100');
});
navbar.addEventListener('mouseleave', function () {
    this.classList.remove('bg-opacity-100');
    this.classList.add('bg-opacity-75');
});