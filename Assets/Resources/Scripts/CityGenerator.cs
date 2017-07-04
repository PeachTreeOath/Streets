using UnityEngine;

public class CityGenerator : MonoBehaviour
{

    /// <summary>
    /// NOTE: Make all sizes odd.
    /// </summary>
    public int buildingSize;
    public int streetSize;
    public int numBuildingsInARow;

    private float tileSize;
    private float localOffset; // Used as starting point when creating a building locally.

    // Use this for initialization
    void Start()
    {
        tileSize = ResourceLoader.instance.wallFab.GetComponent<SpriteRenderer>().size.x;
        localOffset = buildingSize * tileSize / 2;

        LayoutBuildings();
    }

    private void LayoutBuildings()
    {
        // Calculate the centerpoint of the building and feed that to each individual building.
        int centerBuildingIdx = numBuildingsInARow / 2;
        float buildingTileSize = buildingSize * tileSize;
        float streetTileSize = streetSize * tileSize;
        float totalTileSize = buildingTileSize + streetTileSize;
        float startPos = -totalTileSize * centerBuildingIdx;

        for (int i = 0; i < numBuildingsInARow; i++)
        {
            for (int j = 0; j < numBuildingsInARow; j++)
            {
                LayoutBuilding(startPos + i * totalTileSize, startPos + j * totalTileSize);
            }
        }
    }

    private void LayoutBuilding(float xOffset, float yOffset)
    {
        int doorIndex = buildingSize / 2;
        for (int i = 0; i < buildingSize; i++)
        {
            for (int j = 0; j < buildingSize; j++)
            {
                // Layout walls along the edges
                if (i == 0 || j == 0 || i == buildingSize - 1 || j == buildingSize - 1)
                {
                    // Lay doors in the middle of the walls
                    if (i == doorIndex || j == doorIndex)
                    {
                        PlaceTile(ResourceLoader.instance.doorFab, i, j, localOffset, xOffset, yOffset);
                    }
                    else
                    {
                        PlaceTile(ResourceLoader.instance.wallFab, i, j, localOffset, xOffset, yOffset);
                    }
                }
            }
        }
    }

    private void PlaceTile(GameObject tilePrefab, int i, int j, float localOffset, float globalOffsetX, float globalOffsetY)
    {
        float xPos = globalOffsetX - localOffset + i * tileSize + tileSize / 2;
        float yPos = globalOffsetY - localOffset + j * tileSize + tileSize / 2;

        GameObject newTile = Instantiate(tilePrefab, this.transform, false);
        newTile.transform.localPosition = new Vector2(xPos, yPos);
    }
}
