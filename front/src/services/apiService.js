import axios from 'axios';

export default (options) =>
  new Promise((resolve, reject) => {
    axios({
      url: options.url,
      method: options.method,
      params: options.params,
      headers: {
        ...options.headers,
      },
      data: options.data,
      responseType: options.responseType,
    })
      .then((response) => resolve(response.data))
      .catch((error) => {
        console.error(error);

        if (error.response.status === 401) {
          options.url.replace({ path: '/401' });
        }
        if (error.response.status === 403) {
          options.url.replace({ path: '/403' });
        }
        reject(error);
      });
  });
