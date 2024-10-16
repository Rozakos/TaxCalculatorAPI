document.getElementById('taxForm').addEventListener('submit', async function (event) {
    event.preventDefault();

    const country = document.getElementById('country').value;
    const price = parseFloat(document.getElementById('price').value);

    if (!country || isNaN(price)) {
        document.getElementById('result').innerText = 'Please select a valid country and enter a valid price.';
        return;
    }

    const requestBody = {
        country: country,
        price: price
    };

    try {
        const response = await fetch('/api/calculate', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(requestBody)
        });

        if (!response.ok) {
            throw new Error('API request failed');
        }

        const data = await response.json();
        document.getElementById('result').innerText = data.message;
    } catch (error) {
        console.error('Error:', error);
        document.getElementById('result').innerText = 'Failed to calculate tax.';
    }
});
