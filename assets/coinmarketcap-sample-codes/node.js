const axios = require('axios');

const url = 'https://pro-api.coinmarketcap.com/v1/cryptocurrency/quotes/latest'; // Coinmarketcap API url
const api = 'YOUR_API_KEY'; // Replace this with your API key
const parameters = { 'slug': 'bitcoin', 'convert': 'USD' }; // API parameters to pass in for retrieving specific cryptocurrency data

new Promise(async (resolve, reject) => {
  try {
    const response = await axios.get(url, {
      params: parameters,
      headers: {
        'Accepts': 'application/json',
        'X-CMC_PRO_API_KEY': api
      },
    });

    // Receiving the response from the API
    const info = response.data;
    console.log(info); // Displaying JSON data in a visually pleasing format on the terminal for improved readability
    resolve(info);
  } catch (ex) {
    // Error
    console.log(ex);
    reject(ex);
  }
});

