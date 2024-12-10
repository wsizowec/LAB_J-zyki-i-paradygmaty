import re
from collections import Counter

# Lista słów, które są uznawane za "stop words"
stop_words = {"i", "a", "the", "or", "of", "in", "to", "for", "on", "and"}

def analiza_tekstu(text):
    # Zliczanie liczby słów, zdań i akapitów
    words = re.findall(r'\b\w+\b', text.lower())  # Wszystkie słowa w tekście
    sentences = re.split(r'[.!?]+', text)  # Rozdzielanie na zdania
    paragraphs = text.split('\n')  # Rozdzielanie na akapity

    # Liczba słów
    num_words = len(words)
    # Liczba zdań (po usunięciu pustych zdań)
    num_sentences = len([s for s in sentences if s.strip()])
    # Liczba akapitów (po usunięciu pustych akapitów)
    num_paragraphs = len([p for p in paragraphs if p.strip()])

    # 2. Wyszukiwanie najczęściej występujących słów, wykluczając stop words
    filtered_words = [word for word in words if word not in stop_words]
    word_counts = Counter(filtered_words)
    most_common_words = word_counts.most_common(5)  # 5 najczęstszych słów

    # 3. Transformacja słów zaczynających się na "a" lub "A" do ich odwrotności
    transformed_words = [word[::-1] if word.startswith('a') else word for word in words]

    return num_words, num_sentences, num_paragraphs, most_common_words, transformed_words

# Przykładowy tekst

text = """ala ma kota. Kto ma ale.
dziś jest środa. środa minie i tydzień zginie
sdas.
adsa.
ayze.
Bosdp.
"""

# Analiza tekstu
num_words, num_sentences, num_paragraphs, most_common_words, transformed_words = analiza_tekstu(text)

# Wyświetlanie wyników
print(f"Liczba słów: {num_words}")
print(f"Liczba zdań: {num_sentences}")
print(f"Liczba akapitów: {num_paragraphs}")
print(f"Najczęściej występujące słowa: {most_common_words}")
print(f"Przekształcone słowa: {transformed_words}")

