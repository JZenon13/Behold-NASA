import { useState, useEffect } from "react";
import { getAllPhotos } from "./api/marsRoverPhotos";

function App() {
  const [photos, setPhotos] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    getAllPhotos().then((data) => {
      const formattedData = data.map((photo) => {
        const date = new Date(photo.date);
        return { ...photo, date: date.toLocaleDateString() };
      });
      setPhotos(formattedData);
      setLoading(false);
    });
  }, []);

  if (loading) {
    return <h2>Loading Photos from NASA...</h2>;
  }
  return (
    <>
      <h1>Mars Rover Images</h1>
      <div>
        {photos?.map((photo, index) => (
          <div key={index}>
            <h2>{photo.date}</h2>
            {photo.images.map((img, imgIndex) => (
              <img key={imgIndex} src={img} alt={`Mars Rover ${imgIndex}`} />
            ))}
          </div>
        ))}
      </div>
    </>
  );
}

export default App;
