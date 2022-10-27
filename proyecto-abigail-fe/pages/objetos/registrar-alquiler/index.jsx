import Button from "components/Button";
import { SendIcon } from "components/Icons";
import InputControlled from "components/InputControlled";
import Layout from "components/Layout";

import ListBoxOptions from "components/ListBoxOptions";
import Loader from "components/Loader";
import { useState } from "react";
import styles from "./styles.module.css";

export const ESTADOS = [
  {
    id: "1",
    title: "Inquilino/a",
  },
  {
    id: "2",
    title: "Dueño/a",
  },
];

const INPUT_DATA = [
  {
    id: "input_data_1",
    label: "CUI (Previamente debe ser registrado en el formulario Personas)",
    type: "number",
    name: "cui",
    placeholder: "Ej: 1234567890123",
    maxLength: "13",
    required: true,
  },
  {
    id: "input_data_2",
    label: "Identificador de la propiedad",
    type: "number",
    name: "id_propiedad",
    placeholder: "Ej: 503",
    maxLength: "13",
    required: true,
  },
];

export default function RegistrarAlquiler({ currentPage = false }) {
  const [loading, setLoading] = useState(false);

  const handleSubmit = (e) => {
    e.preventDefault();
    setLoading(true);
    const formData = new FormData(e.target);
    const data = Object.fromEntries(formData);
    console.log(data);
    const { nombre, apellido, cui, fecha_Nacimiento, telefono } = data;
    const estado_Civil_Id = data["estado_Civil_Id[id]"];
    const etnia_Id = data["etnia_Id[id]"];
    const genero_Id = data["genero_Id[id]"];
    setLoading(false);
  };

  return (
    <Layout currentPage={currentPage}>
      <h2>Registrar alquiler</h2>
      <form onSubmit={handleSubmit} className={styles.form}>
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

        <ListBoxOptions data={ESTADOS} name="estado_Civil_Id" label="Estado" />

        {/* BOTÓN SUBMIT */}
        <div>
          <Button type="submit">
            Registrar
            <SendIcon />
          </Button>
        </div>
      </form>
      {loading && <Loader />}
    </Layout>
  );
}

export async function getServerSideProps(context) {
  return {
    props: { currentPage: context.resolvedUrl },
  };
}
