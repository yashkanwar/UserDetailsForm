// Define cities object for each state
var cities = {
    'Maharashtra': ['Mumbai', 'Pune', 'Nagpur', 'Aurangabad', 'Nashik', 'Kolhapur'],
    'Gujrat': ['Ahmedabad', 'Surat', 'Vadodara', 'Rajkot', 'Gandhinagar', 'Junagadh'],
    'Delhi': ['New Delhi', 'Old Delhi', 'Dwarka', 'Rohini', 'Pitampura', 'Lajpat Nagar'],
    'Punjab': ['Chandigarh', 'Amritsar', 'Ludhiana', 'Jalandhar', 'Patiala', 'Mohali'],
    'West Bengal': ['Kolkata', 'Howrah', 'Durgapur', 'Siliguri', 'Asansol', 'Burdwan'],
    'Karnataka': ['Bengaluru', 'Mysuru', 'Hubballi', 'Dharwad', 'Mangaluru', 'Bellary']
};

// Function to populate city dropdown based on selected state
function populateCities(selectedState, selectedCity) {
    var cityDropdown = document.getElementById("City");

    // Clear previous city options
    cityDropdown.innerHTML = '';

    // Add "Select City" option only when state changes
    var option = document.createElement('option');
    option.value = '';
    option.textContent = 'Select City';
    cityDropdown.appendChild(option);

    // Populate the city options based on selected state
    var cityOptions = cities[selectedState] || [];
    cityOptions.forEach(function (city) {
        var cityOption = document.createElement('option');
        cityOption.value = city;
        cityOption.textContent = city;

        // Pre-select the city if it matches the saved one
        if (city === selectedCity) {
            cityOption.selected = true;
        }

        cityDropdown.appendChild(cityOption);
    });
}

// Populate city dropdown on page load based on the initially selected state and city
window.onload = function () {
    var stateDropdown = document.getElementById("State");
    var selectedState = stateDropdown.value;
    var selectedCity = stateDropdown.getAttribute("data-city-value") || "";

    // Populate cities based on the existing state and city without resetting to "Select City"
    populateCities(selectedState, selectedCity);
};

// When the state is changed, repopulate the city dropdown and reset the city to "Select City"
document.getElementById("State").addEventListener("change", function () {
    var selectedState = this.value;

    // Call the function to populate cities for the new state, reset city to default
    populateCities(selectedState, "");  // Reset city only if the state is changed
});
