function addImage() {
    const formElement = document.getElementById("add-image-form");
    const addButtonElement = document.getElementById("add-image-btn");
    if (formElement.style.display === "none") {
        formElement.style.display = "block";
        addButtonElement.innerHTML = "סגור"
    } else {
        formElement.style.display = "none";
        addButtonElement.innerHTML = "פתח"
    }
}