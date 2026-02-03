export default function ListarTarefas({ tarefas, aoClicar }) {
  return (
    <ul>
      {tarefas.map((item) => (
        <li key={item.id}>
          <button
            className="botao-tarefa-caderno"
            onClick={() => aoClicar(item.id)}
          >
            <strong>{item.name}</strong>
          </button>
        </li>
      ))}
    </ul>
  );
}
