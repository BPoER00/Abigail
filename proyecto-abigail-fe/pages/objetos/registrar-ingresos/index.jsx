import Button from "components/Button";
import Layout from "components/Layout";
import styles from "./styles.module.css";
import { QRCodeIcon, SendIcon } from "components/Icons";
import RadioOptions from "components/RadioGroup";
import InputControlled from "components/InputControlled";

const OPTIONS = [
  {
    id: 1,
    name: "Delivery",
  },
  {
    id: 2,
    name: "Visitante",
  },
  {
    id: 3,
    name: "Dueño",
  },
  {
    id: 4,
    name: "Servicios emergencia",
  },
  {
    id: 5,
    name: "Servicios externos",
  },
  {
    id: 6,
    name: "Peatón",
  },
  {
    id: 7,
    name: "Vehículo de 2 ruedas",
  },
  {
    id: 8,
    name: "Vehículo de 4 ruedas",
  },
  {
    id: 9,
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
  },
  {
    id: "input_data_2",
    label: "Nombre",
    type: "text",
    name: "nombre",
    placeholder: "Ingrese el nombre",
    maxLength: "100",
    required: true,
  },
  {
    id: "input_data_3",
    label: "Destino",
    type: "text",
    name: "destino",
    placeholder: "Ingrese el destino",
    maxLength: "100",
    required: true,
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
  };

  return (
    <Layout currentPage={currentPage}>
      <section>
        <p>Registrar ingreso</p>
        <Button>
          <QRCodeIcon />
          Escaner QR
        </Button>

        <form onSubmit={handleSubmit}>
          {/* INPUTS: */}
          <div className={styles.containerInputsText}>
            {INPUT_DATA.map(({ id, label, type, name, placeholder, maxLength, required }) => {
              return (
                <div key={id}>
                  <InputControlled
                    label={label}
                    type={type}
                    name={name}
                    placeholder={placeholder}
                    maxLength={maxLength}
                    required={required}
                  />
                </div>
              );
            })}
          </div>

          {/* RADIO BUTTONS: */}
          <RadioOptions title={"Modalidad de ingreso"} OPTIONS={OPTIONS} />

          {/* BOTÓN SUBMIT */}
          <Button type="submit">
            Registrar
            <SendIcon />
          </Button>
        </form>
      </section>
    </Layout>
  );
}

export async function getServerSideProps(context) {
  return {
    props: { currentPage: context.resolvedUrl },
  };
}
