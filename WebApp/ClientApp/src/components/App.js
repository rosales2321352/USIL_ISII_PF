import React from 'react';
import { Contactos } from './Contactos';

const contacts = [
    { id: 1, name: 'John Doe', email: 'john@example.com', phone: '1234567890' },
    { id: 2, name: 'Jane Doe', email: 'jane@example.com', phone: '0987654321' },
];

const App = () => {
    return (
        <div>
            <h1>Contact List</h1>
            <Contactos contacts={contacts} />
        </div>
    );
};

export default App;