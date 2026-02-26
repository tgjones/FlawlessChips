namespace FlawlessChips.Utility;

internal static class LoggingUtility
{
    private static readonly Dictionary<Type, Dictionary<NodeId, string>> NodeNamesCache = new();

    public static string GetNodeName(NodeId nodeId, Type nodeIdsType)
    {
        if (!NodeNamesCache.TryGetValue(nodeIdsType, out var nodeNames))
        {
            var nodeIdFields = nodeIdsType.GetFields()
                .Where(f => f.FieldType == typeof(NodeId));

            nodeNames = [];

            foreach (var nodeIdField in nodeIdFields)
            {
                // We use TryAdd, because there can be duplicates.
                // In that case we just use the first one.
                var nodeIdValue = (NodeId)nodeIdField.GetValue(null)!;

                nodeNames.TryAdd(
                    nodeIdValue,
                    $"({nodeIdValue}):{nodeIdField.Name}");
            }

            NodeNamesCache[nodeIdsType] = nodeNames;
        }

        if (!nodeNames.TryGetValue(nodeId, out var nodeName))
        {
            nodeName = $"({nodeId})";
            nodeNames[nodeId] = nodeName;
        }

        return nodeName;
    }
}
