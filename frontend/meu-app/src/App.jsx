import { useState, useEffect } from "react";
import ListarTarefas from "./components/ListarTarefas";
import RegistrarTarefas from "./components/RegistrarTarefas";
import "./App.css";

function App() {
  const [tarefas, setTarefas] = useState([]);
  const [carregando, setCarregando] = useState(true);

  const API_URL = "https://localhost:7283/api/ToDoList";

  // Função para buscar dados (GET)
  const buscarDados = () => {
    fetch(API_URL)
      .then((res) => res.json())
      .then((dados) => {
        setTarefas(dados.toDoList || []);
        setCarregando(false);
      })
      .catch(() => setCarregando(false));
  };

  useEffect(() => {
    buscarDados();
  }, []);

  // Função que o filho vai chamar após o POST
  const adicionarNaLista = (novaTarefa) => {
    setTarefas((listaAntiga) => [...listaAntiga, novaTarefa]);
  };

  return (
    <>
      {/* Passamos a função de atualização para o filho que registra */}
      <RegistrarTarefas aoAdicionar={adicionarNaLista} />
      <hr />
      {/* Passamos os dados e o status de carregamento para o filho que lista */}
      <ListarTarefas tarefas={tarefas} carregando={carregando} />
    </>
  );
}

export default App;
