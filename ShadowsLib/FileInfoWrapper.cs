using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace ShadowsLib {
    public class FileInfoWrapper {

        private FileInfo _File;
        private string _Sha1Checksum;
        private bool _Marked = false;

        public FileInfoWrapper(FileInfo file) {
            _File = file;
        }

        public FileInfo File {
            get { return _File; }
        }

        public string Sha1Checksum {
            get {
                if(_Sha1Checksum == null) {
                    SHA1Managed sha1Builder = new SHA1Managed();
                    try {
                        using(FileStream stream = File.OpenRead()) {
                            byte[] hash = sha1Builder.ComputeHash(stream);
                            StringBuilder hashBuilder = new StringBuilder(2 * hash.Length);
                            foreach(byte b in hash) {
                                hashBuilder.AppendFormat("{0:X2}", b);
                            }
                            _Sha1Checksum = hashBuilder.ToString();
                            stream.Close();
                        }
                    }
                    catch(UnauthorizedAccessException uae) {
                        throw new ChecksumComputingException(uae.Message, File, uae);
                    }
                    catch(IOException ioe) {
                        throw new ChecksumComputingException(ioe.Message, File, ioe);
                    }
                }
                return _Sha1Checksum;
            }
            set {
                if(value.Length == 40) {
                    _Sha1Checksum = value;
                }
            }
        }

        public bool Marked {
            get { return _Marked; }
            set { _Marked = value; }
        }
    }
}
