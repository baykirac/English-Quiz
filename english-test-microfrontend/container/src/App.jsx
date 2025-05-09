import React, { Suspense } from "react";
import ReactDOM from "react-dom";

const Header = React.lazy(() => import("navbar/Header"));

import "./index.scss";

const App = () => (
  <div>
    <Suspense fallback={<div>Loading...</div>}>
      <Header />
      Container
    </Suspense>
  </div>
);
ReactDOM.render(<App />, document.getElementById("app"));
