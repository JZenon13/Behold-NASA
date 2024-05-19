export const getAllPhotos = async () => {
  try {
    const res = await fetch(
      `http://localhost:5000/api/marsrover/download-images`
    );

    if (!res.ok) {
      throw new Error(`HTTP error! status: ${res.status}`);
    }
    return res.json();
  } catch (error) {
    console.error("There was a problem with the fetch operation: ", error);
  }
};
