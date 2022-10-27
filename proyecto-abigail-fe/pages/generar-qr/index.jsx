import { useState } from "react";
import { QRCodeSVG } from "qrcode.react";
import Button from "components/Button";

import styles from "./styles.module.css";
import Input from "components/Input";

export default function GenerarQr() {
  const [showQr, setShowQr] = useState(false);
  const [value, setValue] = useState({});

  const handleShowQr = () => {
    setShowQr(true);
    // fetch api
    setValue(JSON.stringify({ dpi: "1234567890123", nombre: "Juan Perez", destino: "Casa No. 127" }));
  };

  return (
    <section className={styles.container}>
      <h2>Generador de QR</h2>
      <Input type="number" maxLength="13" label="CUI" placeholder="Ingrese el CUI del vecino/propietario" />
      <Button handleClick={handleShowQr}>Generar QR</Button>
      {showQr && <QRCodeSVG value={value} size={256} />}
    </section>
  );
}
