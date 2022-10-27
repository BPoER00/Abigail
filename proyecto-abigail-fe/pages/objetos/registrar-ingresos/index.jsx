import Button from "components/Button";
import Layout from "components/Layout";
import styles from "./styles.module.css";
import { QRCodeIcon, SendIcon } from "components/Icons";
import RadioOptions from "components/RadioGroup";
import InputControlled from "components/InputControlled";
import Swal from "sweetalert2";

// QR:
import QrReader from "react-qr-scanner";
import { useEffect, useState } from "react";
import Loader from "components/Loader";

const OPTIONS = [
  {
    id: 1,
    name: "Vehículo de 2 ruedas",
  },
  {
    id: 2,
    name: "Vehículo de 4 ruedas",
  },
  {
    id: 3,
    name: "Peatón",
  },
];

const OPTIONS2 = [
  {
    id: "tipo_persona_1",
    name: "Delivery",
  },
  {
    id: "tipo_persona_2",
    name: "Visitante",
  },
  {
    id: "tipo_persona_3",
    name: "Dueño",
  },
  {
    id: "tipo_persona_4",
    name: "Servicios emergencia",
  },
  {
    id: "tipo_persona_5",
    name: "Servicios externos",
  },
  {
    id: "tipo_persona_6",
    name: "Servicios internos",
  },
  {
    id: "tipo_persona_7",
    name: "Otro",
  },
];

const INPUT_DATA = [
  {
    id: "input_data_1",
    label: "DPI",
    type: "text",
    name: "dpi",
    placeholder: "Ingrese el DPI",
    maxLength: "13",
    required: true,
    valueQr: "",
  },
  {
    id: "input_data_2",
    label: "Nombre",
    type: "text",
    name: "nombre",
    placeholder: "Ingrese el nombre",
    maxLength: "100",
    required: true,
    valueQr: "",
  },
  {
    id: "input_data_3",
    label: "Destino",
    type: "text",
    name: "destino",
    placeholder: "Ingrese el destino",
    maxLength: "100",
    required: true,
    valueQr: "",
  },
];

export default function RegistrarIngresos({ currentPage = false }) {
  const handleSubmit = (e) => {
    e.preventDefault();

    // La forma de obtener los datos del formulario, será:
    // const form = e.target;
    // const formData = new FormData(form);
    // const data = Object.fromEntries(formData.entries());
    // console.log(data);
    // const { Nombre, "Número de teléfono": telefono, tratamiento } = data;

    Swal.fire("Registrado exitósamente", "", "success");
  };

  const [showQr, setShowQr] = useState(false);
  const [result, setResult] = useState(INPUT_DATA);
  const [valuesForm, setValuesForm] = useState(INPUT_DATA);
  const [loading, setLoading] = useState(false);

  const handleClickQR = () => {
    setShowQr(true);
  };

  const previewStyle = {
    height: 240,
    width: 320,
  };

  const handleScan = (data) => {
    console.log(data);
    if (data !== null) {
      const dataQr = JSON.parse(data.text);
      const { dpi, nombre, destino } = dataQr;
      const updateValue = valuesForm.map((item) => {
        if (item.id === "input_data_1") {
          return { ...item, valueQr: dpi };
        }
        if (item.id === "input_data_2") {
          return { ...item, valueQr: nombre };
        }
        if (item.id === "input_data_3") {
          return { ...item, valueQr: destino };
        }
      });
      setResult(updateValue);
    }
  };

  const handleError = (err) => {
    console.error(err);
  };

  useEffect(() => {
    setLoading(true);
    setTimeout(() => {
      setValuesForm(result);
      setLoading(false);
      setShowQr(false);
    }, 1000);
  }, [result]);

  return (
    <Layout currentPage={currentPage}>
      <section>
        <h2>Registrar ingreso</h2>
        <Button handleClick={handleClickQR}>
          <QRCodeIcon />
          Escanear QR
        </Button>

        {showQr && <QrReader delay={2000} style={previewStyle} onError={handleError} onScan={handleScan} />}

        {loading ? (
          <Loader />
        ) : (
          <form onSubmit={handleSubmit}>
            {/* INPUTS: */}
            <div className={styles.containerInputsText}>
              {valuesForm.map(({ id, label, type, name, placeholder, maxLength, required, valueQr }) => {
                return (
                  <div key={id}>
                    <InputControlled
                      label={label}
                      type={type}
                      name={name}
                      placeholder={placeholder}
                      maxLength={maxLength}
                      required={required}
                      valueQr={valueQr}
                    />
                  </div>
                );
              })}
            </div>

            {/* RADIO BUTTONS: */}
            <RadioOptions title={"Modalidad de ingreso"} OPTIONS={OPTIONS} />
            <RadioOptions title={"Tipo de persona"} OPTIONS={OPTIONS2} name="tipo_persona" />

            {/* BOTÓN SUBMIT */}
            <Button type="submit">
              Registrar
              <SendIcon />
            </Button>
          </form>
        )}
      </section>
    </Layout>
  );
}

export async function getServerSideProps(context) {
  return {
    props: { currentPage: context.resolvedUrl },
  };
}
