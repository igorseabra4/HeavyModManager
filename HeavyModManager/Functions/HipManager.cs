using HeavyModManager.Classes;
using HeavyModManager.Classes.Assets;
using HipHopFile;

namespace HeavyModManager.Functions;

public static class HipManager
{
    private static Game Game;
    private static Platform Platform;
    private static Endianness Endianness;

    public static void MergeInto(string source, string destination)
    {
        var hipSource = HipFile.FromPath(source);
        var hipDestination = HipFile.FromPath(destination);

        Game = hipDestination.Item2;
        Platform = hipDestination.Item3;
        Endianness = Platform == Platform.GameCube ? Endianness.Big : Endianness.Little;

        MergeInto(hipSource.Item1, hipDestination.Item1);

        File.WriteAllBytes(destination, hipDestination.Item1.ToBytes(hipDestination.Item2, hipDestination.Item3));
    }

    private static void MergeInto(HipFile source, HipFile destination)
    {
        foreach (Section_AHDR sourceAHDR in source.DICT.ATOC.AHDRList)
        {
            switch (sourceAHDR.assetType)
            {
                case AssetType.CollisionTable:
                {
                    var existingAssets = destination.DICT.ATOC.AHDRList.Where(ahdr => ahdr.assetType == AssetType.CollisionTable);
                    if (existingAssets.Any())
                    {
                        foreach (Section_LHDR LHDR in source.DICT.LTOC.LHDRList)
                            LHDR.assetIDlist.Remove(sourceAHDR.assetID);

                        var destinationAHDR = existingAssets.First();
                        var destAsset = new AssetCOLL(destinationAHDR, Endianness);
                        destAsset.Merge(new AssetCOLL(sourceAHDR, Endianness));
                        destinationAHDR.data = destAsset.Serialize(Endianness);
                        continue;
                    }
                    break;
                }
                case AssetType.JawDataTable:
                {
                    var existingAssets = destination.DICT.ATOC.AHDRList.Where(ahdr => ahdr.assetType == AssetType.JawDataTable);
                    if (existingAssets.Any())
                    {
                        foreach (Section_LHDR LHDR in source.DICT.LTOC.LHDRList)
                            LHDR.assetIDlist.Remove(sourceAHDR.assetID);

                        var destinationAHDR = existingAssets.First();
                        var destAsset = new AssetJAW(destinationAHDR, Endianness);
                        destAsset.Merge(new AssetJAW(sourceAHDR, Endianness));
                        destinationAHDR.data = destAsset.Serialize(Endianness);
                        continue;
                    }
                    break;
                }
                case AssetType.LevelOfDetailTable:
                {
                    var existingAssets = destination.DICT.ATOC.AHDRList.Where(ahdr => ahdr.assetType == AssetType.LevelOfDetailTable);
                    if (existingAssets.Any())
                    {
                        foreach (Section_LHDR LHDR in source.DICT.LTOC.LHDRList)
                            LHDR.assetIDlist.Remove(sourceAHDR.assetID);

                        var destinationAHDR = existingAssets.First();
                        var destAsset = new AssetLODT(destinationAHDR, Game, Endianness);
                        destAsset.Merge(new AssetLODT(sourceAHDR, Game, Endianness));
                        destinationAHDR.data = destAsset.Serialize(Game, Endianness);
                        continue;
                    }
                    break;
                }
                case AssetType.PipeInfoTable:
                {
                    var existingAssets = destination.DICT.ATOC.AHDRList.Where(ahdr => ahdr.assetType == AssetType.PipeInfoTable);
                    if (existingAssets.Any())
                    {
                        foreach (Section_LHDR LHDR in source.DICT.LTOC.LHDRList)
                            LHDR.assetIDlist.Remove(sourceAHDR.assetID);

                        var destinationAHDR = existingAssets.First();
                        var destAsset = new AssetPIPT(destinationAHDR, Game, Endianness);
                        destAsset.Merge(new AssetPIPT(sourceAHDR, Game, Endianness));
                        destinationAHDR.data = destAsset.Serialize(Game, Endianness);
                        continue;
                    }
                    break;
                }
                case AssetType.ShadowTable:
                {
                    var existingAssets = destination.DICT.ATOC.AHDRList.Where(ahdr => ahdr.assetType == AssetType.ShadowTable);
                    if (existingAssets.Any())
                    {
                        foreach (Section_LHDR LHDR in source.DICT.LTOC.LHDRList)
                            LHDR.assetIDlist.Remove(sourceAHDR.assetID);

                        var destinationAHDR = existingAssets.First();
                        var destAsset = new AssetSHDW(destinationAHDR, Endianness);
                        destAsset.Merge(new AssetSHDW(sourceAHDR, Endianness));
                        destinationAHDR.data = destAsset.Serialize(Endianness);
                        continue;
                    }
                    break;
                }
                case AssetType.SoundInfo:
                {
                    var existingAssets = destination.DICT.ATOC.AHDRList.Where(ahdr => ahdr.assetType == AssetType.SoundInfo);
                    if (existingAssets.Any())
                    {
                        foreach (Section_LHDR LHDR in source.DICT.LTOC.LHDRList)
                            LHDR.assetIDlist.Remove(sourceAHDR.assetID);

                        var destinationAHDR = existingAssets.First();

                        if (Platform == Platform.GameCube)
                        {
                            if (Game == Game.Incredibles)
                            {
                                var destAsset = new AssetSNDI_GCN_V2(destinationAHDR);
                                destAsset.Merge(new AssetSNDI_GCN_V2(sourceAHDR));
                                destinationAHDR.data = destAsset.Serialize();
                            }
                            else
                            {
                                var destAsset = new AssetSNDI_GCN_V1(destinationAHDR, Game);
                                destAsset.Merge(new AssetSNDI_GCN_V1(sourceAHDR, Game));
                                destinationAHDR.data = destAsset.Serialize(Game);
                            }
                        }
                        else if (Platform == Platform.Xbox)
                        {
                            var destAsset = new AssetSNDI_XBOX(destinationAHDR);
                            destAsset.Merge(new AssetSNDI_XBOX(sourceAHDR));
                            destinationAHDR.data = destAsset.Serialize();
                        }
                        else if (Platform == Platform.PS2)
                        {
                            var destAsset = new AssetSNDI_PS2(destinationAHDR);
                            destAsset.Merge(new AssetSNDI_PS2(sourceAHDR));
                            destinationAHDR.data = destAsset.Serialize(destinationAHDR.assetID);
                        }

                        continue;
                    }
                    break;
                }
                default:
                {
                    var existingAssets = destination.DICT.ATOC.AHDRList.Where(ahdr => ahdr.assetID == sourceAHDR.assetID);
                    if (existingAssets.Any())
                    {
                        foreach (Section_LHDR LHDR in source.DICT.LTOC.LHDRList)
                            LHDR.assetIDlist.Remove(sourceAHDR.assetID);

                        var AHDR = existingAssets.First();

                        AHDR.ADBG = sourceAHDR.ADBG;
                        AHDR.data = sourceAHDR.data;
                        AHDR.assetType = sourceAHDR.assetType;
                        AHDR.flags = sourceAHDR.flags;
                        continue;
                    }
                    break;
                }
            }

            destination.DICT.ATOC.AHDRList.Add(sourceAHDR);
        }

        for (int i = 0; i < source.DICT.LTOC.LHDRList.Count; i++)
            if (source.DICT.LTOC.LHDRList[i].assetIDlist.Count != 0)
                destination.DICT.LTOC.LHDRList.Add(source.DICT.LTOC.LHDRList[i]);

        destination.DICT.LTOC.LHDRList = destination.DICT.LTOC.LHDRList.OrderBy(l => l.layerType, new LayerComparer(Game)).ToList();
    }
}

public class LayerComparer : IComparer<int>
{
    private Game game;

    public LayerComparer(Game game)
    {
        this.game = game;
    }

    private static readonly List<int> layerOrderBFBB = new List<int> {
        (int)LayerType_BFBB.TEXTURE,
        (int)LayerType_BFBB.BSP,
        (int)LayerType_BFBB.JSPINFO,
        (int)LayerType_BFBB.MODEL,
        (int)LayerType_BFBB.ANIMATION,
        (int)LayerType_BFBB.DEFAULT,
        (int)LayerType_BFBB.CUTSCENE,
        (int)LayerType_BFBB.SRAM,
        (int)LayerType_BFBB.SNDTOC
    };

    private static readonly List<int> layerOrderTSSM = new List<int> {
        (int)LayerType_TSSM.TEXTURE,
        (int)LayerType_TSSM.TEXTURE_STRM,
        (int)LayerType_TSSM.BSP,
        (int)LayerType_TSSM.JSPINFO,
        (int)LayerType_TSSM.MODEL,
        (int)LayerType_TSSM.ANIMATION,
        (int)LayerType_TSSM.DEFAULT,
        (int)LayerType_TSSM.CUTSCENE,
        (int)LayerType_TSSM.SRAM,
        (int)LayerType_TSSM.SNDTOC,
        (int)LayerType_TSSM.CUTSCENETOC
    };

    public int Compare(int l1, int l2)
    {
        if (l1 == l2)
            return 0;

        if (game == Game.Scooby && layerOrderBFBB.Contains(l1) && layerOrderBFBB.Contains(l2))
            return layerOrderBFBB.IndexOf(l1) > layerOrderBFBB.IndexOf(l2) ? 1 : -1;

        if (game == Game.BFBB && layerOrderBFBB.Contains(l1) && layerOrderBFBB.Contains(l2))
            return layerOrderBFBB.IndexOf(l1) > layerOrderBFBB.IndexOf(l2) ? 1 : -1;

        if (game == Game.Incredibles)
        {
            if ((l1 == 3 && l2 == 11) || (l1 == 11 && l2 == 3))
                return 0;

            if (layerOrderTSSM.Contains(l1) && layerOrderTSSM.Contains(l2))
                return layerOrderTSSM.IndexOf(l1) > layerOrderTSSM.IndexOf(l2) ? 1 : -1;
        }

        return 0;
    }
}