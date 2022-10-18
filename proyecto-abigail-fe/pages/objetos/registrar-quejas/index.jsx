import Button from "components/Button";
import Layout from "components/Layout";
import styles from "./styles.module.css";
import { SendIcon } from "components/Icons";
import RadioOptions from "components/RadioGroup";
import InputControlled from "components/InputControlled";

const OPTIONS = [
  {
    id: 1,
    name: "Mucho ruido",
  },
  {
    id: 2,
    name: "Ruido a altas horas de la noche",
  },
  {
    id: 3,
    name: "Agresión",
  },
  {
    id: 4,
    name: "Problemas con energía eléctrica",
  },
  {
    id: 5,
    name: "Problemas con el servicio de agua",
  },
  {
    id: 6,
    name: "Discriminación",
  },
  {
    id: 7,
    name: "Problemas con el servicio de cañeria",
  },
  {
    id: 8,
    name: "Conflicto con un personal de servicio",
  },
  {
    id: 9,
    name: "Otro",
  },
];

const INPUT_DATA = [
  {
    id: "input_data_1",
    label: "Nombre",
    type: "text",
    name: "nombre",
    placeholder: "Ingrese el nombre de la queja",
    maxLength: "13",
    required: true,
  },
  {
    id: "input_data_2",
    label: "Ubicación",
    type: "text",
    name: "ubicacion",
    placeholder: "Ingrese donde ocurrió la queja",
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
    // const { nombre, ubicacion, detalles } = data;
    // const queja = data["tipo_de_queja[name]"];
  };

  return (
    <Layout currentPage={currentPage}>
      <section>
        <h2>Registrar quejas</h2>

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
          <RadioOptions title={"Motivo"} OPTIONS={OPTIONS} name="tipo_de_queja" />

          {/* TEXT AREA: */}
          <div className={styles.detallesContainer}>
            <label className={styles.label} htmlFor="detalles">
              Detalles
            </label>
            <textarea
              className={styles.textarea}
              placeholder="Ingrese una breve descripción de la queja"
              name="detalles"
              id="detalles"
              cols="30"
              rows="10"
              required></textarea>
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
