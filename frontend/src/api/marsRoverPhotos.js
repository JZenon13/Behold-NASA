const beUrl = import.meta.env.VITE_BE_URL;

export const getAllPhotos = async () => {
  try {
    const res = await fetch(`${beUrl}`);

    if (!res.ok) {
      throw new Error(`HTTP error! status: ${res.status}`);
    }
    return res.json();
  } catch (error) {
    console.error("There was a problem with the fetch operation: ", error);
  }
};
