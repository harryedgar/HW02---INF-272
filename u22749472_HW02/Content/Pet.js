
    $(document).ready(function () {
        var searchBtn = $("#searchButton");
    var clearBtn = $("#clearButton");
    var typeDrop = $("#type");
    var breedDrop = $("#breed");
    var locationDrop = $("#location");

    searchBtn.click(function () {
            var selectedType = typeDrop.val().toLowerCase();
    var selectedBreed = breedDrop.val().toLowerCase();
    var selectedLocation = locationDrop.val().toLowerCase();

    console.log("Selected Type:", selectedType);
    console.log("Selected Breed:", selectedBreed);
    console.log("Selected Location:", selectedLocation);

    $('.pet-card').each(function () {
                var card = $(this);
    var cardType = card.data("type").toLowerCase();
    var cardBreed = card.data('breed').toLowerCase();
    var cardLocation = card.data('location').toLowerCase();

    var typeMatch = selectedType === "" || cardType === selectedType;
    var breedMatch = selectedBreed === "" || cardBreed === selectedBreed;
    var locationMatch = selectedLocation === "" || cardLocation === selectedLocation;

    if (typeMatch && breedMatch && locationMatch) {
        card.show();
                } else {
        card.hide();
                }
            });

    console.log("Shown cards:", $('.pet-card:visible').length);
    console.log("Hidden cards:", $('.pet-card:hidden').length);
        });

    clearBtn.click(function () {
        $(".pet-card").show();
    typeDrop.val("");
    breedDrop.val("");
    locationDrop.val("");
        });
    });
