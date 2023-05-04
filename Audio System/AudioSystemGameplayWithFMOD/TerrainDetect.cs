using Fusion;
using Fusion.KCC;
using UnityEngine;

public class TerrainDetect : NetworkKCCProcessor
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Rigidbody _rb;

    private Terrain _terrain;
    private int _posX;
    private int _posZ;
    private float[] _textureValues;
    private bool _isPlaying;

    private FMOD.Studio.EventInstance _instance;

    public void RunStep() => PlayFootstep();

    private void GetTerrainTexture()
    {
        ConvertPosition(_playerTransform.position);
        CheckTexture();
    }

    private void InitializeTerrainTextures()
    {
        if (_terrain == null) _terrain = Terrain.activeTerrain;
        _textureValues = new float[_terrain.terrainData.alphamapLayers];
    }

    private void ConvertPosition(Vector3 playerPosition)
    {
        Vector3 terrainPosition = playerPosition - _terrain.transform.position;
        Vector3 mapPosition = new Vector3
            (terrainPosition.x / _terrain.terrainData.size.x,
            0,
            terrainPosition.z / _terrain.terrainData.size.z);

        float xCoord = mapPosition.x * _terrain.terrainData.alphamapWidth;
        float zCoord = mapPosition.z * _terrain.terrainData.alphamapHeight;
        _posX = (int)xCoord;
        _posZ = (int)zCoord;
    }

    private void CheckTexture()
    {
        float[,,] aMap = _terrain.terrainData.GetAlphamaps(_posX, _posZ, 1, 1);

        for (int i = 0; i < _terrain.terrainData.alphamapLayers; i++)
        {
            _textureValues[i] = aMap[0, 0, i];
        }
    }

    private void SetStepSound(int index)
    {

        // In FMOD
        //0- Grass  //1- Concrete  //2- Sand //3- Snow //4- Water 
        //*******
        //  0 = piedra //8 = piedra 2 //9 = cemento
        if (index == 0 || index == 8 || index == 9)
        {
            if (!Object.HasInputAuthority)
            {
                return;
            }
            
            _instance = FMODUnity.RuntimeManager.CreateInstance("event:/Sounds/Player/Footsteps/Footsteps_Concrete");

        }
        // 1 = pasto //  2 = pasto con tierra // 3 = pasto mas crecido // 10 = pasto con tierra 2 // 12 = pasto 2
        if (index == 1 || index == 2 || index == 3 || index == 10 || index == 12)
        {
            if (!Object.HasInputAuthority)
            {
                return;
            }
            _instance = FMODUnity.RuntimeManager.CreateInstance("event:/Sounds/Player/Footsteps/Footsteps_Grass");
        }

        //4 = tierra //5 = tierra 2 // 6 = tierra 3 // 7 = tierra 4 // 11 = tierra 5 //  13 = tierra sin roca
        if (index == 4 || index == 5 || index == 6 || index == 7 || index == 11 || index == 13)
        {
            if (!Object.HasInputAuthority)
            {
                return;
            }
                _instance = FMODUnity.RuntimeManager.CreateInstance("event:/Sounds/Player/Footsteps/Footsteps_Earth");
        }
        _instance.start();


    }
}
