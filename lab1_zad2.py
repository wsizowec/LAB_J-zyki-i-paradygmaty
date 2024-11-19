from collections import deque

def bfs_najkrotsza_sciezka(graf, start, cel):
    def bfs(queue, odwiedzone):
        if not queue:
            return None
        sciezka = queue.popleft()
        ostatni = sciezka[-1]
        if ostatni == cel:
            return sciezka
        for sasiad in graf.get(ostatni, []):
            if sasiad not in odwiedzone:
                odwiedzone.add(sasiad)
                queue.append(sciezka + [sasiad])
        return bfs(queue, odwiedzone)

    return bfs(deque([[start]]), {start})

graf = {
    'A': ['B', 'C'],
    'B': ['A', 'D', 'E'],
    'C': ['A', 'F'],
    'D': ['B'],
    'E': ['B', 'F'],
    'F': ['C', 'E']
}

start = 'A'
cel = 'F'
sciezka = bfs_najkrotsza_sciezka(graf, start, cel)
print(f"Najkrótsza ścieżka z {start} do {cel}: {sciezka}")
