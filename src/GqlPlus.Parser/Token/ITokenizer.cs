using GqlPlus.Result;

namespace GqlPlus.Token;

[SuppressMessage("Naming", "CA1716:Identifiers should not match keywords")]
public interface ITokenizer
{
  bool IgnoreSeparators { get; set; }
  TokenAt At { get; }
  TokenMessages Errors { get; }

  bool AtStart { get; }
  bool AtEnd { get; }

  bool Read();

  void TakeDescription();
  string GetDescription();
  string Description();

  bool Identifier([NotNullWhen(true)] out string? identifier);
  bool Number(out decimal number);
  bool String([NotNullWhen(true)] out string? contents);
  bool Regex([NotNullWhen(true)] out string? regex);

  bool Prefix(char one, out string? identifier, out TokenAt at);
  bool Take(char one);
  bool Take(string text);
  bool TakeAny(out char result, params char[] anyOf);
  bool TakeZero();

  TokenMessage Error(string text);
  TokenMessage Error(string label, string expected);
  IResult<T> Error<T>(string label, string expected);
  IResult<T> Error<T>(string label, string expected, T? result = default);
  IResultArray<T> ErrorArray<T>(string label, string expected, IEnumerable<T>? _ = default);
  IResult<T> Partial<T>(string label, string expected, Func<T> result);
  IResultArray<T> PartialArray<T>(string label, string expected, Func<IEnumerable<T>> result);
}
