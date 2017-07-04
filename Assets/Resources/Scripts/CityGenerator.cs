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
        for (int i = 0; i < buildingSize; i++)
        {
            for (int j = 0; j < buildingSize; j++)
            {
                // Layout walls along the edges
                if (i == 0 || j == 0 || i == buildingSize - 1 || j == buildingSize - 1)
                {
                    PlaceWall(i, j, tileSize, localOffset, xOffset, yOffset);
                }
            }
        }
    }

    private void PlaceWall(int i, int j, float wallSize, float localOffset, float globalOffsetX, float globalOffsetY)
    {
        float xPos = globalOffsetX - localOffset + i * wallSize + wallSize / 2;
        float yPos = globalOffsetY - localOffset + j * wallSize + wallSize / 2;

        GameObject newWall = Instantiate(ResourceLoader.instance.wallFab, this.transform, false);
        newWall.transform.localPosition = new Vector2(xPos, yPos);
    }
}
