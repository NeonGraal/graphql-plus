namespace GqlPlus.Verifier;

internal class Map<T> : Dictionary<string, T>, IMap<T>
{
}

public interface IMap<T> : IDictionary<string, T>
{
}
