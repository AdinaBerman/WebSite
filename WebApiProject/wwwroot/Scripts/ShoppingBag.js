let itemCount = 0;// document.getElementById("itemCount");
let prodInBag = [];
let totalAmount = 0;

const allInBag = () => {
    let i = 0;
    prodInBag = [];
    while (sessionStorage.getItem(`product ${i}`) != null) {
        let p = sessionStorage.getItem(`product ${i}`); 
        prodInBag.push(JSON.parse(p));
        i++;
    }
    showProducts();
}

const showProducts = async () => {
    itemCount = 0;
    totalAmount = 0;
    for (let i = 0; i < prodInBag.length; i++) {
        const tmp = document.querySelector("template");
        const clone = tmp.content.cloneNode(true);
        clone.querySelector(".image").src = "/pictures/" + prodInBag[i].image;
        clone.querySelector(".price").innerText = prodInBag[i].prodPrice;
        clone.querySelector(".descriptionColumn").innerText = prodInBag[i].prodName;
        let btn = clone.getElementById("delete");
        btn.addEventListener('click', () => { deleteFromBag(prodInBag[i]) });
        document.getElementById("tbody").appendChild(clone);
        totalAmount += prodInBag[i].prodPrice;
        itemCount++;
    }

    document.getElementById("itemCount").innerText = itemCount;
    document.getElementById("totalAmount").innerText = totalAmount;
}

const placeOrder = async () => {
    if (!sessionStorage.getItem("user"))
        window.location.href = "homePage.html";

    let orderItemsArr = [];

    for (let i = 0; i < prodInBag.length; i++) {
        if (orderItemsArr.find(p => p.ProductId == prodInBag[i].productId)) {
            const o = orderItemsArr.find(p => p.ProductId == prodInBag[i].productId);
            o.Quentity += 1;
        }
        else {
            let orderItem = {
                ProductId: prodInBag[i].productId,
                Quentity: 1
            }
            orderItemsArr.push(orderItem);   
        }
    }

    const user = sessionStorage.getItem("user");
    const userJson = JSON.parse(user);

    const order = {
        OrderDate: new Date(),
        UserId: userJson.userId,
        OrderSum: totalAmount,
        OrderItems: orderItemsArr
    }

    addOrderToDB(order);
}

const addOrderToDB = async (order) => {
    
    try {
        const res = await fetch('api/Orders',
            {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(order)

            })
        if (!res.ok)
            alert("Sorry, your order isn't created, Try again")
        else {
            const data = await res.json()
            window.location.href = "order.html";
        }
    }

    catch (err) {
        console.log(err);
    }
}

const goShopping = () => {
    window.location.href = "Products.html"
}

const deleteFromBag = (p) => {
    const arr = [];

    let x = 0;
    for (let k = 0; k < prodInBag.length; k++) {
        if (prodInBag[k].productId != p.productId) {
            arr.push(prodInBag[k]);
        }
        else {
            p++;
            if (p > 1)
                arr.push(prodInBag[i]);
        }
    }

    const user = sessionStorage.getItem("user");
    const u = JSON.parse(user);

    sessionStorage.clear();
    sessionStorage.setItem("user", JSON.stringify(u));

    for (let s = 0; s < arr.length; s++) {
        sessionStorage.setItem(`product ${s}`, JSON.stringify(prodInBag[s]));
    }
    document.getElementById("tbody").replaceChildren([]);

    prodInBag = arr;
    showProducts();
}



