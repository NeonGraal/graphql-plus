using System.Runtime.CompilerServices;
using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Decoding;

internal abstract class ObjectDecoder<TModel>
  : DecoderBase<TModel>
  where TModel : class
{
  protected delegate IMessages Decoder(IValue input, out TModel? output);
  protected readonly List<Decoder> Decoders = [];

  protected ObjectDecoder()
    => Decoders.Add(DecodeObject);

  public override IMessages Decode(IValue input, out TModel? output)
  {
    IMessages messages = Messages.New;
    foreach (Decoder decoder in Decoders) {
      messages.Add(decoder(input, out output));
      if (output is not null) {
        return messages;
      }
    }

    output = null;
    return messages.Add(Err($"Unable to decode {input}"));
  }

  protected virtual IMessages DecodeObject(IValue input, out TModel? output)
  {
    if (input.TryGetMap(out IMap<IValue>? map)
        || input.TryGetList(out IEnumerable<IValue>? list)
          && list.Count() == 1 && list.First().TryGetMap(out map)) {
      return DecodeMap(map, out output);
    }

    output = null;
    return new Messages(Err($"Unable to decode {input}"));
  }

  protected void DecodeScalarField<T>(IMessages messages, IDecoder<T> decoder, IMap<IValue> map, out T? value, T? defaultValue = default, [CallerArgumentExpression(nameof(value))] string valueExpr = "")
  {
    string fieldName = valueExpr.Split()[1];
    if (map.TryGetValue(fieldName, out IValue? fieldValue)) {
      messages.Add(decoder.Decode(fieldValue, out value));
    } else {
      value = defaultValue;
    }
  }

  protected void DecodeListField<T>(IMessages messages, IDecoder<T> decoder, IMap<IValue> map, out T[] value, [CallerArgumentExpression(nameof(value))] string valueExpr = "")
  {
    value = [];
    string fieldName = valueExpr.Split()[1];
    if (map.TryGetValue(fieldName, out IValue? fieldValue)) {
      if (fieldValue.TryGetList(out IEnumerable<IValue>? list)) {
        messages.Add(DecodeList(list, decoder, out IEnumerable<T>? result));
        if (result?.Count() > 0) {
          value = [.. result];
          return;
        }
      }

      messages.Add(Err($"Unable to decode list field '{fieldName}' with value {fieldValue}"));
    }
  }

  protected abstract IMessages DecodeMap(IMap<IValue> map, out TModel? output);
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

  protected abstract IMessages DecodeNames(IValue input, out TModel? output);

  protected IMessages DecodeFilterMap(IMap<IValue> map, out FilterModel? output)
  {
    IMessages messages = Messages.New;

    DecodeListField(messages, _nameFilter, map, out string[]? names);
    DecodeScalarField(messages, _boolean, map, out bool matchAliases, true);
    DecodeListField(messages, _nameFilter, map, out string[]? aliases);
    DecodeScalarField(messages, _boolean, map, out bool returnByAlias);
    DecodeScalarField(messages, _boolean, map, out bool returnReferencedTypes);

    output = new(names) {
      MatchAliases = matchAliases,
      Aliases = aliases,
      ReturnByAlias = returnByAlias,
      ReturnReferencedTypes = returnReferencedTypes
    };

    return messages;
  }

  protected IMessages DecodeFilterNames(IValue input, out FilterModel? output)
  {
    IMessages messages = Messages.New;
    output = null;

    if (input.TryGetText(out string? strValue)) {
      output = new FilterModel([strValue]);
    } else if (input.TryGetList(out IEnumerable<IValue>? list)) {
      messages.Add(DecodeList(list, _nameFilter, out IEnumerable<string> names));
      if (names.Any()) {
        output = new FilterModel([.. names]);
      }
    }

    return messages;
  }
}

internal class FilterModelDecoder(IDecoder<bool> boolean, IDecoder<string> nameFilter)
  : FilterModelDecoder<FilterModel>(boolean, nameFilter)
{
  protected override IMessages DecodeMap(IMap<IValue> map, out FilterModel? output)
    => DecodeFilterMap(map, out output);

  protected override IMessages DecodeNames(IValue value, out FilterModel? output)
    => DecodeFilterNames(value, out output);
}

internal class CategoryFilterModelDecoder(
  IDecoder<bool> boolean,
  IDecoder<string> nameFilter,
  IDecoder<CategoryOption> resolution
) : FilterModelDecoder<CategoryFilterModel>(boolean, nameFilter)
{
  protected override IMessages DecodeMap(IMap<IValue> map, out CategoryFilterModel? output)
  {
    IMessages messages = DecodeFilterMap(map, out FilterModel? filterModel);
    if (filterModel is null) {
      output = null;
      return messages;
    }

    DecodeListField(messages, resolution, map, out CategoryOption[]? resolutions);

    output = new(filterModel) { Resolutions = resolutions ?? [], };
    return messages;
  }

  protected override IMessages DecodeNames(IValue value, out CategoryFilterModel? output)
  {
    IMessages messages = DecodeFilterNames(value, out FilterModel? filterModel);

    output = filterModel is null ? null : new(filterModel);
    return messages;
  }
}

internal class TypeFilterModelDecoder(
  IDecoder<bool> boolean,
  IDecoder<string> nameFilter,
  IDecoder<TypeKindModel> kind
) : FilterModelDecoder<TypeFilterModel>(boolean, nameFilter)
{
  protected override IMessages DecodeMap(IMap<IValue> map, out TypeFilterModel? output)
  {
    IMessages messages = DecodeFilterMap(map, out FilterModel? filterModel);
    if (filterModel is null) {
      output = null;
      return messages;
    }

    DecodeListField(messages, kind, map, out TypeKindModel[]? kinds);

    output = new(filterModel) { Kinds = kinds ?? [], };
    return messages;
  }

  protected override IMessages DecodeNames(IValue value, out TypeFilterModel? output)
  {
    IMessages messages = DecodeFilterNames(value, out FilterModel? filterModel);

    output = filterModel is null ? null : new(filterModel);
    return messages;
  }
}
