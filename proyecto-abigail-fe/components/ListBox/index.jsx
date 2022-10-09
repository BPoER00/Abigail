import { useState } from "react";
import { Listbox } from "@headlessui/react";

import styles from "./styles.module.css";
import Link from "next/link";

export default function ListBox({
  data,
  name = "listbox",
  leftIcon = null,
  rightIcon = null,
  placeholder = "Selecciona una opción",
  currentPage = false,
}) {
  // El ListBox se cierra automáticamente cuando se hace click fuera de él.
  // Puede que sea un problema o no. Creo que se debe a que el contexto del ListBox
  // son diferentes. Es decir, estoy pasando un param data 1 y 2 totalmente distintos.
  const [selected, setSelected] = useState(data[0]);

  console.log({ currentPage });

  return (
    <Listbox name={name} value={selected} onChange={setSelected}>
      <div className={styles.subContainer}>
        <Listbox.Button className={styles.listBoxBtn}>
          {typeof icon === "function" && leftIcon()}
          <div className={styles.placeholder}>
            <div>
              {leftIcon ?? null}
              {placeholder}
            </div>
            {rightIcon ?? null}
          </div>
          {typeof icon === "function" && rightIcon()}
        </Listbox.Button>
        <Listbox.Options className={styles.optionsContainer}>
          {data.map((item) => (
            <Listbox.Option
              key={item.id}
              className={({ active }) => `${styles.option} ${active && styles.active}`}
              value={item}>
              {() => (
                <Link href={item.path}>
                  {currentPage === item.path ? (
                    <span className={`${currentPage && styles.optionSelected}`}>{item.title}</span>
                  ) : (
                    <span className={styles.clearItem}>{item.title}</span>
                  )}
                </Link>
              )}
            </Listbox.Option>
          ))}
        </Listbox.Options>
      </div>
    </Listbox>
  );
}
