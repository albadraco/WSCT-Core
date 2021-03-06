using WSCT.Core.APDU;
using WSCT.Wrapper;

namespace WSCT.Core
{
    /// <summary>
    /// Interface for card channels, ie objects capable of managing access to a smartcard.
    /// </summary>
    public interface ICardChannel
    {
        #region >> Properties

        /// <summary>
        /// Accessor to the protocol T in use.
        /// </summary>
        Protocol Protocol { get; }

        /// <summary>
        /// Accessor to the name of the reader in use.
        /// </summary>
        string ReaderName { get; }

        #endregion

        #region >> Methods

        /// <summary>
        /// Associates a card context and reader to the instance.
        /// </summary>
        /// <param name="context">Context of the resource manager.</param>
        /// <param name="readerName">Name of the reader to use for this instance.</param>
        void Attach(ICardContext context, string readerName);

        /// <summary>
        /// Establishes a connection with the smartcard contained by the reader.
        /// </summary>
        /// <param name="shareMode">Shared access mode.</param>
        /// <param name="preferedProtocol">Protocol T to use.</param>
        /// <returns><see cref="ErrorCode.Success"/> if succeeded.</returns>
        ErrorCode Connect(ShareMode shareMode, Protocol preferedProtocol);

        /// <summary>
        /// Terminates the connection with the smartcard in the reader.
        /// </summary>
        /// <param name="disposition">What to do with the card after disconnection.</param>
        /// <returns><see cref="ErrorCode.Success"/> if succeeded.</returns>
        ErrorCode Disconnect(Disposition disposition);

        /// <summary>
        /// Retrieves an attribute from the reader, in the context of the card used.
        /// </summary>
        /// <param name="attrib">Identifier to the attrib to retrieve.</param>
        /// <param name="buffer">Buffer that will be set to the value of the attrib.</param>
        /// <returns><see cref="ErrorCode.Success"/> if succeeded.</returns>
        ErrorCode GetAttrib(Attrib attrib, ref byte[] buffer);

        /// <summary>
        /// Retrieves current status of the smartcard in the reader.
        /// </summary>
        /// <returns><see cref="ErrorCode.Success"/> if succeeded.</returns>
        State GetStatus();

        /// <summary>
        /// Re-establishes a connection with the smartcard contained by the reader.
        /// </summary>
        /// <param name="shareMode">Shared access mode.</param>
        /// <param name="preferedProtocol">Protocol T to use.</param>
        /// <param name="initialization">Reconnection mode.</param>
        /// <returns><see cref="ErrorCode.Success"/> if succeeded.</returns>
        ErrorCode Reconnect(ShareMode shareMode, Protocol preferedProtocol, Disposition initialization);

        /// <summary>
        /// Sends a service request to the smart card and expects to receive data back from the card.
        /// </summary>
        /// <param name="command">Command to send to the smartcard.</param>
        /// <param name="response">Response received from the smartcard.</param>
        /// <returns><see cref="ErrorCode.Success"/> if succeeded.</returns>
        ErrorCode Transmit(ICardCommand command, ICardResponse response);

        #endregion
    }
}