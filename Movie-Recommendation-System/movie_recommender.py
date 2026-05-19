# My movie recommondation system.
# Ali Mohamed alhami





import pandas as pd
from sklearn.feature_extraction.text import CountVectorizer
from sklearn.metrics.pairwise import cosine_similarity

# 1. Create a mini-dataset of movies
data = {
    'movie_id': [1, 2, 3, 4, 5, 6],
    'title': ['The Dark Knight', 'Interstellar', 'Inception', 'The Conjuring', 'Insidious', 'Gladiator'],
    'genres': ['Action Crime Drama', 'Sci-Fi Adventure Drama', 'Sci-Fi Action Thriller', 'Horror Mystery', 'Horror Thriller', 'Action Adventure Drama']
}

df = pd.DataFrame(data)
print("--- Our Movie Dataset ---")
print(df[['title', 'genres']])
print("-" * 30)

# 2. Convert text (genres) into numbers that math can understand
vectorizer = CountVectorizer()
genre_matrix = vectorizer.fit_transform(df['genres'])

# 3. Calculate the mathematical similarity between all movies using Cosine Similarity
similarity_scores = cosine_similarity(genre_matrix)

# 4. The Recommendation Engine Logic
def get_recommendations(movie_title, top_n=2):
    try:
        movie_idx = df[df['title'] == movie_title].index[0]
    except IndexError:
        return f"Movie '{movie_title}' not found in the database!"
    
    similar_movies = list(enumerate(similarity_scores[movie_idx]))
    sorted_similar_movies = sorted(similar_movies, key=lambda x: x[1], reverse=True)
    
    print(f"\nBecause you liked '{movie_title}', our AI recommends:")
    
    count = 0
    for item in sorted_similar_movies:
        idx = item[0]
        if idx != movie_idx:
            print(f"-> {df['title'].iloc[idx]} (Genre: {df['genres'].iloc[idx]})")
            count += 1
            if count >= top_n:
                break

# 5. Run and Test our AI System Interactively!
if __name__ == "__main__":
    print("\n" + "="*40)
    print("Welcome to your AI Movie Recommender System!")
    print("="*40)
    
    # Show available movies so the user knows what's in our database
    print("\nAvailable movies in database:")
    for t in df['title']:
        print(f"- {t}")
        
    print("\n" + "-"*40)
    user_choice = input("Enter a movie title from the list above: ")
    
    # Run the engine based on what YOU type
    get_recommendations(user_choice)