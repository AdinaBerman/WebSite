
let products = [];


const getProduct = async (minPrice, maxPrice, desc, allCategory) => {
    let url = `https://localhost:44358/api/Products`;
    if (desc || minPrice || maxPrice || allCategory) {
        url += `?`;
    }

    if (desc) url += `&desc=${desc}`;
    if (minPrice) url += `&minPrice=${minPrice}`;
    if (maxPrice) url += `&maxPrice=${maxPrice}`;
    if (allCategory) {
        for (let i = 0; i < allCategory.length; i++) {
            url += `&categoryIds=${allCategory[i]}`
        }
    }
    const res = await fetch(url);

    try {
        if (res.status == 400)
            console.log("Error in connection DB")
        else if (res.status == 204)
            console.log("no products found")
        else {
            //products = res;
            const prod = await res.json()
            return prod;
        }
    }
    catch (e) {
        console.log("error in show products");
        throw e;
    }
}

const getCategory = async () => {
    const res = await fetch(`api/Categories`)
    try {
        if (res.status == 400)
            console.log("Error in connection DB")
        else if (res.status == 204)
            console.log("no category found")
        else {
            //products = res;
            const category = await res.json()
            return category;
        }
    }
    catch (e) {
        console.log("error in show category");
        throw e;
    }
}

const showProducts = async (minPrice, maxPrice, desc, allCategory) => {
    
    products = await getProduct(minPrice, maxPrice, desc, allCategory);

    let u = 0;
    while (sessionStorage.getItem(`product ${u}`) != null) {
        u++;
        document.getElementById("ItemsCountText").innerText++;
    }

    for (let i = 0; i <= products.length; i++) {
        const tmp = document.querySelector("#temp-card");
        const clone = tmp.content.cloneNode(true);
        clone.querySelector("img").src = "/pictures/" + products[i].image;
        clone.querySelector("h1").innerText = products[i].prodName;
        clone.querySelector(".price").innerText = products[i].prodPrice + "$";
        clone.querySelector(".description").innerText = products[i].prodDescription;
        let p = products[i];
        let btn = clone.querySelector("button");
        btn.addEventListener("click", () => { addToCart(p) });
        document.getElementById("PoductList").appendChild(clone);
    }

 
  
}

const showCatedory = async () => {
    const category = await getCategory();
    
    for (var i = 0; i <= category.length; i++) {
        const tmp = document.querySelector("#temp-category");
        const clone = tmp.content.cloneNode(true);
        clone.querySelector("input").value = category[i].categoryName;
        clone.querySelector("input").id = category[i].categoryId;
        clone.querySelector("span.OptionName").innerText = category[i].categoryName;
        clone.querySelector("label").for = category[i].categoryName;
        document.getElementById("categoryList").appendChild(clone);
    }
}
    

const filterProducts = async () => {

    const minPrice = document.getElementById("minPrice").value;
    const maxPrice = document.getElementById("maxPrice").value;
    const desc = document.getElementById("nameSearch").value;
    let category = document.querySelectorAll(".opt");

    const allCategory = [];

    for (let i = 0; i < category.length; i++) {
        if (category[i].checked) {
            allCategory.push(category[i].id);
        }
    }

    document.getElementById("PoductList").replaceChildren();
    products = await showProducts(minPrice, maxPrice, desc, allCategory);

}


let i = 0;
let propInBag = [];

const addToCart = (product) => {
    while (sessionStorage.getItem(`product ${i}`) != null) {
        let p = sessionStorage.getItem(`product ${i}`);
        propInBag.push(JSON.parse(p));
        i++;
    }

    document.getElementById("ItemsCountText").innerText++;
    sessionStorage.setItem(`product ${i}`, JSON.stringify(product));
    i++;
}

showProducts();
showCatedory();