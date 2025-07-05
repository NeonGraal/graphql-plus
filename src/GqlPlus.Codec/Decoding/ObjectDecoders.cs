using System.Runtime.CompilerServices;
using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Decoding;

internal abstract class ObjectDecoder<TModel>
  : IDecoder<TModel>
  where TModel : class
{
  protected delegate TModel? Decoder(IValue value);
  protected readonly List<Decoder> Decoders = [];

  protected ObjectDecoder()
    => Decoders.Add(DecodeObject);

  public TModel? Decode(IValue value)
  {
    foreach (Decoder decoder in Decoders) {
      TModel? result = decoder(value);
      if (result is not null) {
        return result;
      }
    }

    return null;
  }

  protected virtual TModel? DecodeObject(IValue value)
  {
    if (value.TryGetMap(out IMap<IValue>? map)
        || value.TryGetList(out IEnumerable<IValue>? list)
          && list.Count() == 1 && list.First().TryGetMap(out map)) {
      return DecodeMap(map);
    }

    return null;
  }

  protected void DecodeScalarField<T>(IDecoder<T> decoder, IMap<IValue> map, out T? value, T? defaultValue = default, [CallerArgumentExpression(nameof(value))] string valueExpr = "")
  {
    string fieldName = valueExpr.Split()[1];
    if (map.TryGetValue(fieldName, out IValue? fieldValue)) {
      value = decoder.Decode(fieldValue) ?? defaultValue;
    } else {
      value = defaultValue;
    }
  }

  protected void DecodeListField<T>(IDecoder<T> decoder, IMap<IValue> map, out T[] value, [CallerArgumentExpression(nameof(value))] string valueExpr = "")
  {
    string fieldName = valueExpr.Split()[1];
    if (map.TryGetValue(fieldName, out IValue? fieldValue)) {
      DecodeList(decoder, fieldValue, out value);
    } else {
      value = [];
    }
  }

  protected void DecodeList<T>(IDecoder<T> decoder, IValue input, out T[] value)
  {
    if (input.TryGetList(out IEnumerable<IValue>? list)) {
      value = [.. list.Select(decoder.Decode).Where(v => v is not null).Cast<T>()];
    } else {
      value = [];
    }
  }

  protected abstract TModel? DecodeMap(IMap<IValue> map);
}

internal abstract class FilterModelDecoder<TModel>
  : ObjectDecoder<TModel>
  where TModel : FilterModel
{
  private readonly IDecoder<bool> _boolean;
  private readonly IDecoder<string> _nameFilter;

  public FilterModelDecoder(IDecoder<bool> boolean, IDecoder<string> nameFilter)
  {
    _boolean = boolean;
    _nameFilter = nameFilter;

    Decoders.Add(DecodeNames);
  }

  protected abstract TModel? DecodeNames(IValue value);

  protected FilterModel? DecodeFilterMap(IMap<IValue> map)
  {
    DecodeListField(_nameFilter, map, out string[]? names);
    DecodeScalarField(_boolean, map, out bool matchAliases, true);
    DecodeListField(_nameFilter, map, out string[]? aliases);
    DecodeScalarField(_boolean, map, out bool returnByAlias);
    DecodeScalarField(_boolean, map, out bool returnReferencedTypes);

    return new(names) {
      MatchAliases = matchAliases,
      Aliases = aliases,
      ReturnByAlias = returnByAlias,
      ReturnReferencedTypes = returnReferencedTypes
    };
  }

  protected FilterModel? DecodeFilterNames(IValue value)
  {
    DecodeList(_nameFilter, value, out string[]? names);
    if (names.Length > 0) {
      return new FilterModel(names);
    }

    return null;
  }
}

internal class FilterModelDecoder(IDecoder<bool> boolean, IDecoder<string> nameFilter)
  : FilterModelDecoder<FilterModel>(boolean, nameFilter)
{
  protected override FilterModel? DecodeMap(IMap<IValue> map)
    => DecodeFilterMap(map);

  protected override FilterModel? DecodeNames(IValue value)
    => DecodeFilterNames(value);
}

internal class CategoryFilterModelDecoder(
  IDecoder<bool> boolean,
  IDecoder<string> nameFilter,
  IDecoder<CategoryOption> resolution
) : FilterModelDecoder<CategoryFilterModel>(boolean, nameFilter)
{
  protected override CategoryFilterModel? DecodeMap(IMap<IValue> map)
  {
    FilterModel? filterModel = DecodeFilterMap(map);
    if (filterModel is null) {
      return null;
    }

    DecodeListField(resolution, map, out CategoryOption[]? resolutions);

    return new(filterModel) { Resolutions = resolutions ?? [], };
  }

  protected override CategoryFilterModel? DecodeNames(IValue value)
  {
    FilterModel? filterModel = DecodeFilterNames(value);

    return filterModel is null ? null : new(filterModel);
  }
}

internal class TypeFilterModelDecoder(
  IDecoder<bool> boolean,
  IDecoder<string> nameFilter,
  IDecoder<TypeKindModel> kind
) : FilterModelDecoder<TypeFilterModel>(boolean, nameFilter)
{
  protected override TypeFilterModel? DecodeMap(IMap<IValue> map)
  {
    FilterModel? filterModel = DecodeFilterMap(map);
    if (filterModel is null) {
      return null;
    }

    DecodeListField(kind, map, out TypeKindModel[]? kinds);

    return new(filterModel) { Kinds = kinds ?? [], };
  }

  protected override TypeFilterModel? DecodeNames(IValue value)
  {
    FilterModel? filterModel = DecodeFilterNames(value);

    return filterModel is null ? null : new(filterModel);
  }
}
