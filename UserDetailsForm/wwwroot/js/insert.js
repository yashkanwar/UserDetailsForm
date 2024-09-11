document.addEventListener('DOMContentLoaded', function () {
    var stateDropdown = document.getElementById('State');
    var cityDropdown = document.getElementById('City');

    var cities = {
        'Maharashtra': ['Mumbai', 'Pune', 'Nagpur', 'Aurangabad', 'Nashik', 'Kolhapur'],
        'Gujrat': ['Ahmedabad', 'Surat', 'Vadodara', 'Rajkot', 'Gandhinagar', 'Junagadh'],
        'Delhi': ['New Delhi', 'Old Delhi', 'Dwarka', 'Rohini', 'Pitampura', 'Lajpat Nagar'],
        'Punjab': ['Chandigarh', 'Amritsar', 'Ludhiana', 'Jalandhar', 'Patiala', 'Mohali'],
        'West Bengal': ['Kolkata', 'Howrah', 'Durgapur', 'Siliguri', 'Asansol', 'Burdwan'],
        'Karnataka': ['Bengaluru', 'Mysuru', 'Hubballi', 'Dharwad', 'Mangaluru', 'Bellary']
    }


    stateDropdown.addEventListener('change', function () {
        var selectedState = stateDropdown.value;
        var cityOptions = cities[selectedState] || [];

        cityDropdown.innerHTML = '<option value="">Select City</option>';
        cityOptions.forEach(function (city) {
            var option = document.createElement('option');
            option.value = city;
            option.textContent = city;
            cityDropdown.appendChild(option);
        });
    });
});