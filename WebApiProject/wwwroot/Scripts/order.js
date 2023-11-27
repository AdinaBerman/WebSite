const goShopping = () => {
    const user = sessionStorage.getItem("user");
    sessionStorage.clear();
    sessionStorage.setItem("user", user);
    window.location.href = "Products.html"
}