import React, { useEffect, useState } from 'react';

export const Sections = () => {

  const [loading, setLoading] = useState(false);
  const [sections, setSections] = useState([]);
  
  useEffect(() => {
    const fetchSections = async () => {
      setLoading(true);

      const response = await fetch('/api/statistic/sections');
      const data = await response.json();
      
      setLoading(false)
      setSections(data);
    };

    fetchSections();
  }, []);

  return (
    loading 
      ? <p><em>Loading...</em></p>
      : (
        <table className='table table-striped' aria-labelledby="tabelLabel">
          <thead>
            <tr>
              <th>Name</th>
            </tr>
          </thead>
          <tbody>
            {sections.map(section =>
              <tr key={section.name}>
                <td>{section.name}</td>
              </tr>
            )}
          </tbody>
        </table>
      )
  );
};