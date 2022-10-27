import Swal from "sweetalert2";

import Button from "components/Button";
import Layout from "components/Layout";
import styles from "./styles.module.css";
import { SendIcon } from "components/Icons";
import RadioOptions from "components/RadioGroup";
import InputControlled from "components/InputControlled";

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
  },
];

export default function RegistrarEgresos({ currentPage = false }) {
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

  return (
    <Layout currentPage={currentPage}>
      <section>
        <h2>Registrar egreso</h2>
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
          <RadioOptions title={"Modalidad de egreso"} OPTIONS={OPTIONS} />
          <RadioOptions title={"Tipo de persona"} OPTIONS={OPTIONS2} />

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
