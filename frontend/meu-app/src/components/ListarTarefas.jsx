export default function ListarTarefas({ tarefas, carregando }) {
  // Recebe via Props
  if (carregando) return <p>Carregando tarefas...</p>;

  return (
    <div>
      <h2>Lista de tarefas</h2>
      <ul>
        {tarefas.map((item) => (
          <li key={item.id}>
            <strong>{item.name}</strong>
          </li>
        ))}
      </ul>
    </div>
  );
}
