import logo from "./logo.svg";
import "./App.css";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import { QuotesScreen, PaymentScreen } from "./screens";
import { NavBar } from "./components";

function App() {
  return (
    <Router>
      <div className="App">
        <NavBar />
        <Routes>
          <Route path="/quotes/:orderId" element={<QuotesScreen />} />
          <Route path="/quotes/:orderId/:quoteId" element={<PaymentScreen />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
