document.getElementById('taxForm').addEventListener('submit', async function (event) {
    event.preventDefault();

    const country = document.getElementById('country').value;
    const price = document.getElementById('price').value;
    const vatRate = document.getElementById('vatRate').value;

    const requestBody = {
        country: country,
        price: parseFloat(price),
        vatRate: parseFloat(vatRate)
    };

    try {
        const response = await fetch('https://localhost:5001/api/calculate', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(requestBody)
        });

        // Log the response status for debugging
        console.log('Response Status:', response.status);

        // Check if the response is okay (status code 200-299)
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const data = await response.json();
        console.log('Response Data:', data);  // Log the response data for debugging
        document.getElementById('result').innerText = data.message;
    } catch (error) {
        console.error('Error:', error);  // Log detailed error information
        document.getElementById('result').innerText = 'Failed to calculate tax.';
    }
});
