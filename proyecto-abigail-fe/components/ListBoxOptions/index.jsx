import { useState, Fragment } from "react";
import { Listbox, Transition } from "@headlessui/react";
import Image from "next/image";

import styles from "./styles.module.css";

export default function ListBox({ data, name, label = undefined }) {
  const [selected, setSelected] = useState(data[0]);

  return (
    <div>
      {label && (
        <label className={styles.label} htmlFor={name}>
          {label}
        </label>
      )}
      <Listbox name={name} value={selected} onChange={setSelected}>
        <div className={styles.subContainer}>
          <Listbox.Button className={styles.listBoxBtn}>
            <span className={styles.placeholder}>{selected.title}</span>
            <Image src={"/icons/chevron-down.svg"} height="20" width="20" alt="Presione para desplegar opciones" />
          </Listbox.Button>
          <Transition as={Fragment} leave="transition ease-in duration-100" leaveFrom="opacity-100" leaveTo="opacity-0">
            <Listbox.Options className={styles.optionsContainer}>
              {data.map((Treatment) => (
                <Listbox.Option
                  key={Treatment.id}
                  className={({ active }) => `${styles.option} ${active && styles.active}`}
                  value={Treatment}>
                  {({ selected }) => (
                    <>
                      {selected ? (
                        <span>
                          <Image src={"/icons/check.svg"} height="24" width="24" alt="Opión seleccionada" />
                        </span>
                      ) : null}
                      <span className={`${selected && styles.optionSelected}`}>{Treatment.title}</span>
                    </>
                  )}
                </Listbox.Option>
              ))}
            </Listbox.Options>
          </Transition>
        </div>
      </Listbox>
    </div>
  );
}
