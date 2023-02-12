const navbar = document.getElementById('navbar');
const loginPage = document.getElementById('loginPage');
const registerPage = document.getElementById('registerPage');
const main = document.getElementById('main');

navbar.addEventListener('mouseover', function () {
    this.classList.remove('bg-opacity-75');
    this.classList.add('bg-opacity-100');
});
navbar.addEventListener('mouseleave', function () {
    this.classList.remove('bg-opacity-100');
    this.classList.add('bg-opacity-75');
});

if (loginPage || registerPage) {
    main.classList.remove('card');
}