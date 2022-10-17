import { useState } from "react";
import Router from "next/router";

import "../styles/globals.css";
import Loader from "components/Loader";

function MyApp({ Component, pageProps }) {
  const [loading, setLoading] = useState(false);

  Router.events.on("routeChangeStart", () => setLoading(true));
  Router.events.on("routeChangeComplete", () => setLoading(false));

  return (
    <>
      {loading && <Loader />}
      <Component {...pageProps} />
    </>
  );
}

export default MyApp;
