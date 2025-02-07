import socket
import struct

HOST = "127.0.0.1"
PORT = 12345

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
sock.bind((HOST, PORT))

print(f"Listening on {HOST}:{PORT}...")

while True:
    data, addr = sock.recvfrom(1024)
    if len(data) == 4:
        num = struct.unpack('!f', data)[0]
        print(f"Received: {num} from {addr}")
    else:
        print(f"Incorrect data received: {data}")
