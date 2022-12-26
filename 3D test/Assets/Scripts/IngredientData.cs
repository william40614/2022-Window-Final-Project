using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientData : MonoBehaviour
{
    public IngredientType type;
    public float processTime = 7.4f;
    public float cookTime = 6f;
    public Mesh rawMesh;
    public Mesh processedMesh;
    public Mesh cookedMesh;
    public Material ingredientMaterial;
    public Sprite sprite;
}
