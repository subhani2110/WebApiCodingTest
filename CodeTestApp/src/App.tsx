import React, { useState } from 'react';
import reactLogo from './assets/react.svg';
import viteLogo from '/vite.svg';
import './App.css';

function App() {
  const [num1, setNumber1] = useState(0);
  const [num2, setNumber2] = useState(0);
  const [sum, setSum] = useState(null);

  const calculateSum = async () => {
    try {
      const response = await fetch('https://localhost:7092/add?num1=' + num1 + '&num2=' + num2, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        }
      });

      if (response.ok) {
        const data = await response.json();
        setSum(data);
      } else {
        console.error('API request failed');
      }
    } catch (error) {
      console.error('Error:', error);
    }
  };

  return (
    <>
      <div className="card">
        <input
          type="number"
          value={num1}
          onChange={(e) => setNumber1(parseInt(e.target.value, 10))}
        />
        <input
          type="number"
          value={num2}
          onChange={(e) => setNumber2(parseInt(e.target.value, 10))}
        />
        <button onClick={calculateSum}>Calculate Sum</button>
        {sum !== null && <p>Sum: {sum}</p>}
      </div>
    </>
  );
}

export default App;
