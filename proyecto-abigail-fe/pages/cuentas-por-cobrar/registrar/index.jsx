import Button from "components/Button";
import Layout from "components/Layout";
import styles from "./styles.module.css";
import { SendIcon } from "components/Icons";
import InputControlled from "components/InputControlled";

const INPUT_DATA = [
  {
    id: "input_data_1",
    label: "Código de vecino",
    type: "text",
    name: "codigo_vecino",
    placeholder: "Ingrese el código del vecino",
    maxLength: "13",
    required: true,
  },
  {
    id: "input_data_2",
    label: "Código de propiedad",
    type: "text",
    name: "codigo_propiedad",
    placeholder: "Ingrese el código de la propiedad",
    maxLength: "100",
    required: true,
  },
  {
    id: "input_data_3",
    label: "Valor de cuota",
    type: "text",
    name: "valor_cuota",
    placeholder: "Ingrese el destino",
    maxLength: "100",
    required: true,
  },
  {
    id: "input_data_4",
    label: "Fecha en que comienza la cuota",
    type: "date",
    name: "fecha_inicio_cuota",
    placeholder: "Ingrese el destino",
    maxLength: "100",
    required: true,
  },
  {
    id: "input_data_5",
    label: "Frecuencia de pagos",
    type: "text",
    name: "frecuencia_pagos",
    placeholder: "Quincenal, mensual, etc.",
    maxLength: "100",
    required: true,
  },
];

export default function RegistrarCuentasPorCobrar({ currentPage = false }) {
  const handleSubmit = (e) => {
    e.preventDefault();

    // La forma de obtener los datos del formulario, será:
    // const form = e.target;
    // const formData = new FormData(form);
    // const data = Object.fromEntries(formData.entries());
    // console.log(data);
    // const { codigo_vecino, codigo_propiedad, valor_cuota, fecha_inicio_cuota, frecuencia_pagos } = data;
  };

  return (
    <Layout currentPage={currentPage}>
      <section>
        <h2>Registrar ingreso</h2>

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
